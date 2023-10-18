namespace HospitalSystemManagement.Model
{
    public class MedicalHistory
    {
        public int MedicalHistoryID { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Medication { get; set; }
        public string OtherDetails { get; set; }
    }
}
