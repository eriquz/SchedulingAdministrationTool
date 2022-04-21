using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SAT.DATA.EF/*.SATmetadata*/
{
    #region Course
    public class CourseMetadata
    {
        //public int CourseID { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "*Course Name is Required")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less")]
        public string CourseName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "*Course description is Required")]
        [StringLength(500, ErrorMessage = "*Must be 500 characters or less")]
        [UIHint("MultilineText")]
        public string CourseDescription { get; set; }

        [Display(Name = "Credits")]
        [Required(ErrorMessage = "*How many Credit hours is Required")]
        [Range(1, 4, ErrorMessage = "*Must be in between 1-4.")]
        public byte CreditHours { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(250, ErrorMessage = "*Must be 250 characters or less")]
        public string Curriculum { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(500, ErrorMessage = "*Must be 500 characters or less")]
        public string Notes { get; set; }

        [Display(Name = "Active")]
        [Required(ErrorMessage = "*Is Active?")]
        public bool IsActive { get; set; }
    }
    [MetadataType(typeof(CourseMetadata))]
    public partial class Course { }

    #endregion

    #region Enrollment
    public class EnrollmentMetadata
    {
        //public int EnrollmentID { get; set; }

        [Required(ErrorMessage = "*Student ID is Required")]

        public int StudentID { get; set; }

        [Required(ErrorMessage = "*Scheduled class ID is Required")]

        public int ScheduledClassID { get; set; }

        [Required(ErrorMessage = "*Enrollment Date is Required")]

        public System.DateTime EnrollmentDate { get; set; }
    }
    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }
    #endregion

    #region ScheduledClasses
    public class ScheduledClassMetadata
    {
        //public int ScheduledClassID { get; set; }
        [Display(Name = "Course ID")]
        [Required(ErrorMessage = "Course ID is required")]
        public int CourseID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public System.DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "\"End Date\" is required")]
        public System.DateTime EndDate { get; set; }

        [Display(Name = "Instructor Name")]
        [Required(ErrorMessage = "Instructor Name is required")]
        [StringLength(40, ErrorMessage = "*Instructor Name must be 40 characters or less")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage = "Location is required (usually a room number)")]
        [StringLength(20, ErrorMessage = "*Location must be 20 characters or less")]
        public string Location { get; set; }


        [Display(Name = "Scheduled Class Status ID")]
        [Range(0, int.MaxValue, ErrorMessage = "*Value must be a valid number, 0 or larger")]
        [Required(ErrorMessage = "Scheduled Class Status ID is required")]
        public int SCSID { get; set; }
    }
    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass {
        public string Term
        {
            get { return Course.CourseName + " - Begins " + StartDate.ToShortDateString() + " at " + Location; }
        }
    }
    #endregion

    #region ScheduledClassStatusMetadata
    public class ScheduledClassStatusMetadata
    {
        //public int SCSID { get; set; }
        [Display(Name = " Scheduled Class Status")]
        [Required(ErrorMessage = "Scheduled Class status is required")]
        [StringLength(50, ErrorMessage = "*Scheduled Class Status Name must be 50 characters or less")]
        public string SCSName { get; set; }
    }
    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }
    #endregion

    #region StudentMetadata
    public class StudentMetadata
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, ErrorMessage = "*First Name must be 20 characters or less")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "*Last name must be 20 characters or less")]
        public string LastName { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(15, ErrorMessage = "*Must be 15 characters or less")]
        public string Major { get; set; }


        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less")]
        public string Address { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(25, ErrorMessage = "*Must be 25 characters or less")]
        public string City { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(2, ErrorMessage = "*Must be 2 characters or less")]
        public string State { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(10, ErrorMessage = "*Must be 10 characters or less")]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(13, ErrorMessage = "*Must be 13 characters or less")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(60, ErrorMessage = "*Email must be 60 characters or less")]
        public string Email { get; set; }

        [Display(Name = "Image")]
        [StringLength(100, ErrorMessage = "*Email must be 100 characters or less")]
        [UIHint("MultilineText")]
        public string PhotoURL { get; set; }

        [Display(Name = "Student Status ID")]
        [Required(ErrorMessage = "Student Status ID is required")]
        [Range(0, int.MaxValue, ErrorMessage = "*Value must be a valid number, 0 or larger")]
        public int SSID { get; set; }

    }
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student {

        [Display(Name="Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
    #endregion

    #region StudentStatusMetadata
    public class StudentStatusMetadata
    {
        //public int SSID { get; set; }
        [Display(Name = "Student Status")]
        [Required(ErrorMessage = "Student Status is required")]
        [StringLength(30, ErrorMessage = "*Student Status Name must be 30 characters or less")]
        public string SSName { get; set; }

        [Display(Name = "Student Status Description")]
        [StringLength(250, ErrorMessage = "*Student Status Description must be 250 characters or less")]
        [UIHint("MultilineText")]
        public string SSDescription { get; set; }
    }
    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus { }
    #endregion
}