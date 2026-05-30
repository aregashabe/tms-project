///.......................m1 lab 2 .....................................................
public class EnrollmenService{
    public EnrollmentRecord ProcessRegistration(Student?student,Course?course){
if(student is null){
    throw new ArgumentNullException(nameof(student),"student is null");
}
if(course is null){
    throw new ArgumentNullException(nameof(course),"course is null");
}
if(course.Capacity<=0){
    throw new InvalidOperationException("course is full");
}
string standing =student.GPA switch{
>=3.5m =>"honors",
>=2.5m =>"good standing",
<2.5m =>"Academic Warning"
};
Console.WriteLine($"{student.Name} is in {standing}");
   DateTime enrolledAt = DateTime.Now;
return new EnrollmentRecord(
    student.Id,
    course.Code,
    enrolledAt
);
    }
}