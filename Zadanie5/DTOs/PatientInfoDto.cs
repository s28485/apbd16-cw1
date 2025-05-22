namespace Cwiczenia5.DTOs;

public class PatientInfoDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
    public List<PatientPrescriptionDto> Prescriptions { get; set; }
    
}

public class PatientPrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public PrescriptionDoctorDto Doctor { get; set; }
    public List<PatientMedicamentDto> Medicaments { get; set; }
}

public class PatientMedicamentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int Dose { get; set; }
    public string Details { get; set; }

}