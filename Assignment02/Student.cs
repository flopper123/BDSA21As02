
using System;

namespace Assignment02
{

  public class Student
  {

    public int Id { get; }
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public Status Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }

    public Student(int id) {
      this.Id = id;
    }

    public string ToString(){
      throw new NotImplementedException();
    }


  }

    
}