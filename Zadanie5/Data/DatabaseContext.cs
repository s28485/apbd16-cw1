using System.Data.Common;
using Cwiczenia5.Models;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia5.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    
    protected DatabaseContext(){}
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient(){IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", BirthDate = new DateTime(1980, 12, 14)},
            new Patient(){IdPatient = 2, FirstName = "Barbara", LastName = "Tomasik", BirthDate = new DateTime(1968, 9, 6)},
            new Patient(){IdPatient = 3, FirstName = "Anna", LastName = "Nowak", BirthDate = new DateTime(1977, 4, 19)}
        });

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor(){IdDoctor = 1, FirstName = "Marek", LastName = "Jakubowski", Email = "mjakubowski@doktor.pl"},
            new Doctor(){IdDoctor = 2, FirstName = "Ewa", LastName = "Wójcik", Email = "ewojcik@doktor.pl"}
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament(){IdMedicament = 1, Name = "Apap", Description = "Przeciwbolowy", Type = "Tabletki"},
            new Medicament(){IdMedicament = 2, Name = "Octeangin", Description = "Na gardlo", Type = "Tabletki do ssania"},
            new Medicament(){IdMedicament = 3, Name = "Amoxicilin", Description = "Antybiotyk", Type = "Tabletki"},
            new Medicament(){IdMedicament = 4, Name = "Ibuprofen", Description = "Przeciwbolowy, przeciwzapalny", Type = "Kapsulki"}
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription()
            {
                IdPrescription = 1, 
                Date = new DateTime(2025, 03, 17), 
                DueDate = new DateTime(2025, 04, 17),
                IdPatient = 1,
                IdDoctor = 2
            },
            new Prescription()
            {
                IdPrescription = 2,
                Date = new DateTime(2025, 03, 24),
                DueDate = new DateTime(2025, 04, 24),
                IdPatient = 2,
                IdDoctor = 2
            },
            new Prescription()
            {
                IdPrescription = 3,
                Date = new DateTime(2025, 4, 2),
                DueDate = new DateTime(2025, 5, 2),
                IdPatient = 3,
                IdDoctor = 1
            }
        });

        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
            new PrescriptionMedicament()
            {
                IdPrescription = 1,
                IdMedicament = 1,
                Dose = 400,
                Details = "Brac dwa razy dziennie"
            },
            new PrescriptionMedicament()
            {
                IdPrescription = 2,
                IdMedicament = 2,
                Dose = 2,
                Details = "Maksymalnie 3 razy na dzien"
            },
            new PrescriptionMedicament()
            {
                IdPrescription = 2,
                IdMedicament = 3,
                Dose = 250,
                Details = "Rano i wieczorem o tej samej porze"
            },
            new PrescriptionMedicament()
            {
                IdPrescription = 3,
                IdMedicament = 2,
                Dose = 4,
                Details = "Maksymalnie 3 razy na dzien"
            }
        });
        
        base.OnModelCreating(modelBuilder);
    }

}