// // step 1and step 2
// string? region=null;
// Console.WriteLine($"{region?.ToUpper()}");
// string displayRegion=region??"unassigned";
// Console.WriteLine(displayRegion);
// region??="Addis Ababa";
// Console.WriteLine(region);

// //step3

// String studentName="Abeba";
// string studentId="STU-001";
// int enrollmentCount=3;
// decimal grantAmount=1999.99m;
// DateTime enrolledAt=DateTime.UtcNow;
// string?campaRegion=null;
// Console.WriteLine($"student:{studentName} {studentId}");
// Console.WriteLine($"Course: {enrollmentCount}");
// Console.WriteLine($"Grant:{grantAmount:F2}");
// Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
// Console.WriteLine($"Campaus: {campaRegion??"Not assigned"}");
// //Exercise 2
// double grantPerStuden = 1999.99;
// double totalAllocatio = grantPerStuden * 100_000;
// Console.WriteLine($"Total allocated (double): {totalAllocatio}");
// decimal grantPerStudent = 1999.99m;
// decimal totalAllocation = grantPerStudent * 100_000m;
// Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
// Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");
// // Exercise 3: part 1
// var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
// Console.WriteLine(enrollment);
// var corrected = enrollment with { CourseCode = "CS-402" };
// Console.WriteLine(corrected);
// //part 2
// var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
// Console.WriteLine($"Same data? {enrollment == duplicate}"); // True
// var course = new Course{ Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
// Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");
// //part 3
// var s = new  Student { Id = "S1", Name ="Abeba", Age = 20, GPA= 3.8m };
// Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// // new Student { Id = "S2", Name = "", Age = 20, GPA= 3.0m };
// // Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// // new Student { Id = "S3", Name = "Test", Age = 12, GPA = 3.0m };
// // Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// // new Student { Id = "S4", Name = "Test", Age = 20, GPA = 5.0m };
// Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// //exercise 3B
// void PrintGradeReport(IEnumerable<IGradable> assessments)
// {
// Console.WriteLine("--- Grade Report---");
// foreach (var item in assessments)
// {
// Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
// }
// }
// // Test it — one array holds two completely different types
// IGradable[] cohortAssessments = [
// new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
// new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore =85m}
// ];
// PrintGradeReport(cohortAssessments);
// //.......................................... m1 lab 2 exercise 4...................................
// var service=new EnrollmenService();
// var validStudent= new Student{Id="stu-001",Name="Abeba",Age=23, GPA=3.2m};
// var validCourse=new Course{Code="maths123",Title="applidMathematcs",Capacity=3};
// var result=service.ProcessRegistration(validStudent,validCourse);
// Console.WriteLine($"Enrolled {result.StudentId} in Course {result.CourseCode} ");
// //test 2
// try
// {
// service.ProcessRegistration(null, validCourse);
// }
// catch (ArgumentNullException ex)
// {
// Console.WriteLine($"Guard caught: {ex.ParamName}");
// }
// // test 3
// var fullCourse = new Course { Code = "CS-402", Title = "Full Course", Capacity = 1 };
// fullCourse.EnrolledCount = 1;
// try
// {
//     service.ProcessRegistration(validStudent, fullCourse);
// }
// catch (InvalidOperationException ex)
// {
// Console.WriteLine($"Business rule: {ex.Message}");
// }
// //.............................................excersice 5..........................................
// //........................step 1.......................
// List<Student> students=new(){
//     new Student{Id="s1",Name="Dereje",Age=33,GPA=3.8m},
//     new Student{Id="s2",Name="Geremew",Age=25,GPA=2.4m},
//     new Student{Id="s3",Name="Serkalem",Age=30,GPA=3.1m},
//     new Student{Id="s4", Name="Yeabsira",Age=28,GPA=3.7m},
//     new Student{Id="s5",Name="Meseret",Age=42,GPA=3.4m},
//     new Student{Id="s6",Name="Tesfaye",Age=24,GPA=3.6m},
//     new Student{Id="s7",Name="MERON",Age=22,GPA=2.0m},
//     new Student{Id="s8",Name="yONAS",Age=21,GPA=1.8m}
// };
// //........................step 2.......................
// var stu=students.Where(s=>s.GPA >= 3.5m);
// foreach(var n in stu){
//     Console.WriteLine(n.Name);
// }
// var gpades=students.OrderByDescending(m=>m.GPA);
// foreach(var l in gpades){
// Console.WriteLine(l.Name);
// }
// //........................step 3.......................
// decimal averageGpa = students.Average(s=>s.GPA);
// Console.WriteLine($"Average GPA {averageGpa:F2}");
// //........................step 4.......................
// var standingGroups=students.GroupBy(s=>s.GPA switch{
//   >=3.5m=>"honor",
//     >=2.5m=>"good standing",
//     >=2.0m=>"academic warnning",
//     _ => "fail"
// });
// foreach (var c in standingGroups)
// {
//     Console.WriteLine($"\n{c.Key}:");

//     foreach (var student in c)
//     {
//         Console.WriteLine(student.Name);
//     }
// }

// //........................step 5.......................
// string[] backendCourses=["c#","asp.net course"];
// string[]frontendCourses=["typeScript","angular"];
// string[] fullCourses=[..backendCourses,..frontendCourses];
// Console.WriteLine(string.Join(", ", fullCourses));

//.............................exercise 6 Step 1 See Thread Starvation in Numbers.........................
using System.Diagnostics;
var sw =Stopwatch.StartNew();
for (int i = 0; i < 5; i++)
{
Thread.Sleep(300); // Thread is HELD for 300ms cannot serve anyone else
}
Console.WriteLine($"Blocking sequential: {sw.ElapsedMilliseconds}ms");
// ASYNC BUTSTILL SEQUENTIAL: Thread released, but calls are one-at-a-time
sw.Restart();
for (int i = 0; i < 5; i++)
{
await Task.Delay(300); // Thread released while waiting but still sequential
}
Console.WriteLine($"Async sequential: {sw.ElapsedMilliseconds}ms");
// THE RIGHT WAY:Asyncparallel all 5 start simultaneously
sw.Restart();
var tasks = Enumerable.Range(0, 5).Select(_ => Task.Delay(300));
await Task.WhenAll(tasks);
Console.WriteLine($"Async parallel: {sw.ElapsedMilliseconds}ms");
//.................................step 2
async Task<Student> FetchStudentAsync(string id)
{
Console.WriteLine($" Fetching {id}...");
await Task.Delay(300); // Simulate database latency
return new Student
{
Id = id,
Name=$"Student-{id}",
Age = 20,
GPA=id switch
{
"S1" => 3.8m,
"S2" => 2.4m,
"S3" => 3.5m,
"S4" => 1.9m,
"S5" => 3.2m,
_ =>2.5m
}
};
}

async Task<Course> FetchCourseAsync(string code)
{
Console.WriteLine($" Fetching course {code}...");
await Task.Delay(200); // Simulate database latency
return new Course
{
    Code = code,
Title = $"Course-{code}",
Capacity = code switch
{
"CRS-101" => 2,
"CRS-201" => 30,
"CRS-301" => 15,
_ =>25
}
};
}
sw.Restart();
// Start all fetches simultaneously students AND courses
string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];
var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));
// Both arrays load concurrently
Student[] students = await Task.WhenAll(studentTasks);
Course[] courses = await Task.WhenAll(courseTasks);
Console.WriteLine($"\nLoaded {students.Length} students and {courses.Length} courses in {sw.ElapsedMilliseconds}ms");
foreach (var s in students)
{
Console.WriteLine($" {s.Name} GPA: {s.GPA}");
}