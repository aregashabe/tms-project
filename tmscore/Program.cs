// step 1and step 2
string? region=null;
Console.WriteLine($"{region?.ToUpper()}");
string displayRegion=region??"unassigned";
Console.WriteLine(displayRegion);
region??="Addis Ababa";
Console.WriteLine(region);

//step3

String studentName="Abeba";
string studentId="STU-001";
int enrollmentCount=3;
decimal grantAmount=1999.99m;
DateTime enrolledAt=DateTime.UtcNow;
string?campaRegion=null;
Console.WriteLine($"student:{studentName} {studentId}");
Console.WriteLine($"Course: {enrollmentCount}");
Console.WriteLine($"Grant:{grantAmount:F2}");
Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campaus: {campaRegion??"Not assigned"}");
//Exercise 2
double grantPerStuden = 1999.99;
double totalAllocatio = grantPerStuden * 100_000;
Console.WriteLine($"Total allocated (double): {totalAllocatio}");
decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100_000m;
Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");
// Exercise 3: part 1
var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
Console.WriteLine(enrollment);
var corrected = enrollment with { CourseCode = "CS-402" };
Console.WriteLine(corrected);
//part 2
var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
Console.WriteLine($"Same data? {enrollment == duplicate}"); // True
var course = new Course{ Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");
//part 3
var s = new  Student { Id = "S1", Name ="Abeba", Age = 20, GPA= 3.8m };
Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// new Student { Id = "S2", Name = "", Age = 20, GPA= 3.0m };
// Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// new Student { Id = "S3", Name = "Test", Age = 12, GPA = 3.0m };
// Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// new Student { Id = "S4", Name = "Test", Age = 20, GPA = 5.0m };
Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
//exercise 3B
void PrintGradeReport(IEnumerable<IGradable> assessments)
{
Console.WriteLine("--- Grade Report---");
foreach (var item in assessments)
{
Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
}
}
// Test it — one array holds two completely different types
IGradable[] cohortAssessments = [
new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore =85m}
];
PrintGradeReport(cohortAssessments);
