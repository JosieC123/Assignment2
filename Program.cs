// ask for input
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());

    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

    // random number generator
    Random rnd = new();
    // create file
    StreamWriter sw = new("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{

/*
Week of Sep, 06, 2020
 Su Mo Tu We Th Fr Sa
 -- -- -- -- -- -- --
  7  4 10  6  9 11  7

Week of Sep, 13, 2020
 Su Mo Tu We Th Fr Sa
 -- -- -- -- -- -- --
  7  4 10  6  9 11  7
*/

    // TODO: parse data file
    string file = "data.txt";
    if (File.Exists(file))
    {

        StreamReader sr = new(file);
        while (!sr.EndOfStream)
        {
                string? line = sr.ReadLine(); 
                //make array
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split(',','|');
                string str= arr[0];
                DateTime dateTime = DateTime.Parse(str);
                //display array
                Console.WriteLine("Week of {0:MMM}, {0:dd}, {0:yyyy}\n-- -- -- -- -- -- -- \n {1,1} {2} {3} {4} {5} {6} {7}",dateTime,arr[1],arr[2],arr[3],arr[4],arr[5],arr[6],arr[7]);
        }
        sr.Close();
 


    }
}