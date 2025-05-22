using Cwiczenia5.DTOs;
using Cwiczenia5.Models;

namespace Cwiczenia5.Services;

public interface IDbService
{
    Task AddPrescription(PrescriptionDto prescriptionDto);
    Task<PatientInfoDto> GetPatientInfo(int idPatient);
}