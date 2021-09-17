using System;

namespace Assignment02
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime first = DateTime.Now;
      DateTime snd = new DateTime(2020, 4, 15, 09, 30, 0);
      Console.WriteLine(first);
      Console.WriteLine(snd);
      Console.WriteLine(first.CompareTo(snd));
      Console.WriteLine(
        DateTime.Compare(
          first,
          new DateTime( 2023, (9 + 8) % 12, 15, 15, 00, 0)
        )
      );
    }
  }
}
