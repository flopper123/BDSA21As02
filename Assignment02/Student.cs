using System;
using System.Text;

namespace Assignment02
{

  public class Student
  {

    public int Id { get; }
    public string GivenName { get; set; }
    public string Surname { get; set; }

    public Status Status {
      get { return this.findStatus(); }
    }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }

    public Student(int id)
    {
      this.Id = id;
    }

    private Status findStatus()
    {
      const int EARLIER = -1;
      const int LATER   = 1;
      
      DateTime now = DateTime.Now;      

      // Check for dropout
      if (DateTime.Compare(now, EndDate) == LATER && DateTime.Compare(EndDate, GraduationDate) == EARLIER)
      {
        return Status.DROPOUT;
      }

      // Check for graduation
      if (DateTime.Compare(now, GraduationDate) == LATER) return Status.GRADUATED;

      // Check for new
      if (DateTime.Compare(now, StartDate.AddMonths(2)) == EARLIER) return Status.NEW;

      // Check for active
      if (DateTime.Compare(now, GraduationDate) == EARLIER) return Status.ACTIVE;

      return Status.ACTIVE;
    }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder("");

      builder.AppendFormat("#{0} - {1}, {2}: {3} {4}", Id, Surname, GivenName, statusToStr(), formatTime());

      return builder.ToString();
    }

    private string formatTime() {
      StringBuilder builder = new StringBuilder("");
      builder.AppendFormat(
        "({0} - {1})",
        StartDate.Year,
        EndDate.Year
      );
      return builder.ToString();
    }

    private string statusToStr() {
      switch(Status) {
        case Status.ACTIVE: return "Active";
        case Status.NEW: return "New";
        case Status.GRADUATED: return "Graduated";
        case Status.DROPOUT: return "Dropout";
        default: return "???";
      }
    }


  }

    
}