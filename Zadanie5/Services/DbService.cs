using Cwiczenia5.Data;
using Microsoft.EntityFrameworkCore;
using Cwiczenia5.DTOs;
using Cwiczenia5.Models;

namespace Cwiczenia5.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _dbContext;

    public DbService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPrescription(PrescriptionDto prescriptionDto)
    {
        if(prescriptionDto.Medicaments.Count > 10)
            throw new ArgumentException("Medicament list is too large");
        
        if (prescriptionDto.DueDate < prescriptionDto.Date)
            throw new ArgumentException("Due date must be greater than or equal to date");

        var patient = await _dbContext.Patients
            .FirstOrDefaultAsync(p =>
                p.FirstName == prescriptionDto.Patient.FirstName
                && p.LastName == prescriptionDto.Patient.LastName
                && p.BirthDate == prescriptionDto.Patient.BirthDate);

        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = prescriptionDto.Patient.FirstName,
                LastName = prescriptionDto.Patient.LastName,
                BirthDate = prescriptionDto.Patient.BirthDate
            };
            
            _dbContext.Patients.Add(patient);
            await _dbContext.SaveChangesAsync();
        }
        
        var doctor = await _dbContext.Doctors
            .FirstOrDefaultAsync(d => 
                d.FirstName == prescriptionDto.Doctor.FirstName
                && d.LastName == prescriptionDto.Doctor.LastName
                && d.Email == prescriptionDto.Doctor.Email);
        
        if (doctor == null)
            throw new ArgumentException("Doctor not found");

        var medIds = prescriptionDto.Medicaments.Select(m =>
            m.IdMedicament).ToList();

        var medicams = await _dbContext.Medicaments
            .Where(m => medIds.Contains(m.IdMedicament)).ToListAsync();
        
        if(medicams.Count != medIds.Count)
            throw new ArgumentException("At least one Medicament not found");

        var prescription = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = doctor.IdDoctor,
            PrescriptionMedicaments = prescriptionDto.Medicaments.Select(m =>
                new PrescriptionMedicament
                {
                    IdMedicament = m.IdMedicament,
                    Dose = m.Dose,
                    Details = m.Details
                }).ToList()

        };
        _dbContext.Prescriptions.Add(prescription);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PatientInfoDto> GetPatientInfo(int idPatient)
    {
        var patient = await _dbContext.Patients
            .Include(p => p.Prescriptions).ThenInclude(pre => pre.Doctor)
            .Include(p => p.Prescriptions).ThenInclude(pre => pre.PrescriptionMedicaments)
            .ThenInclude(pmed => pmed.IdMedicament)
            .FirstOrDefaultAsync(p => p.IdPatient == idPatient);

        if (patient == null)
            return null;

        return new PatientInfoDto
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = patient.Prescriptions.OrderBy(p => p.DueDate).Select(p => new PatientPrescriptionDto
            {
                Date = p.Date,
                DueDate = p.DueDate,
                Doctor = new PrescriptionDoctorDto
                {
                    FirstName = p.Doctor.FirstName,
                    LastName = p.Doctor.LastName,
                    Email = p.Doctor.Email
                },
                Medicaments = p.PrescriptionMedicaments.Select(pmed => new PatientMedicamentDto
                {
                    Name = pmed.Medicament.Name,
                    Description = pmed.Medicament.Description,
                    Type = pmed.Medicament.Type,
                    Dose = pmed.Dose,
                    Details = pmed.Details
                }).ToList()
            }).ToList()
        };
    }
}