public class TmsDatabaseException : Exception
{
public string Operation { get; }
public TmsDatabaseException(string operation, string message)
: base(message)
{
Operation = operation;
}
public TmsDatabaseException(string operation, string message, Exception innerException)
: base(message, innerException)
{
    Operation = operation;
}
}
public class CapacityReachedException : InvalidOperationException
{
public string CourseCode { get; }
public CapacityReachedException(string courseCode)
: base($"Course {courseCode} has reached maximum capacity.")
{
    CourseCode = courseCode;
}

public CapacityReachedException(string courseCode, Exception innerException)
: base($"Course {courseCode} has reached maximum capacity.", innerException)
{
CourseCode = courseCode;
}
}