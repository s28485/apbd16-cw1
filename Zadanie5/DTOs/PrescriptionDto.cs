namespace Cwiczenia5.DTOs;

public class PrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public PrescriptionPatientDto Patient { get; set; }
    public PrescriptionDoctorDto Doctor { get; set; }
    public List<PrescMedicamentDto> Medicaments { get; set; }
    
}

public class PrescriptionPatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class PrescriptionDoctorDto{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

public class PrescMedicamentDto
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Details { get; set; }

}