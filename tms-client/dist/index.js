"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const assessment_model_1 = require("./models/assessment.model");
const polyfill_1 = require("@js-temporal/polyfill");
const student_model_1 = require("./models/student.model");
const enrollment_model_1 = require("./models/enrollment.model");
const course_model_1 = require("./models/course.model");
const api_response_model_1 = require("./models/api-response.model");
const student = {
    id: "STU-001",
    name: "Hana Tadesse",
    enrollmentDate: polyfill_1.Temporal.Now.instant(),
};
function processStudent(raw) {
    if ((0, student_model_1.isStudent)(raw)) {
        const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
        console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
    }
    else {
        console.error("Invalid student data received");
    }
}
processStudent({ id: "STU-001", name: "Hana", gpa: 3.7 });
processStudent(42);
console.log((0, student_model_1.parseStudent)({ id: "STU-001", name: "Hana" }));
// Prints a valid Student object
// parseStudent({ id: 42, name: "Test" });
// Throws: TypeError: Expected id to be a string, received number
const quiz = {
    id: "QUIZ-001",
    kind: "quiz",
    title: "SQL Basics",
    correctAnswers: 8,
    totalQuestions: 10,
};
const lab = {
    id: "LAB-001",
    kind: "lab",
    title: "REST API Project",
    functionalityScore: 85,
    codeQualityScore: 90,
};
console.log(`Quiz grade: ${(0, assessment_model_1.calculateGrade)(quiz)}%`); // 80
console.log(`Lab grade: ${(0, assessment_model_1.calculateGrade)(lab)}%`); // 87
// Verify readonly try this line and check the compiler error:
// quiz.id = "QUIZ-999";
// ERROR: Cannot assign to 'id' because it is a read-only property
const pending = {
    status: "PENDING",
    requestedAt: polyfill_1.Temporal.Now.instant(),
    studentId: "STU-001",
    courseId: "CRS-101",
};
console.log((0, enrollment_model_1.describeEnrollment)(pending));
const webDev = {
    status: "ACTIVE",
    enrolledCount: 28,
    startDate: polyfill_1.Temporal.PlainDate.from("2026-09-01"),
};
console.log((0, course_model_1.describeCourse)(webDev));
//.........................exercise 6.........................................................
const studentRes = {
    status: "success",
    data: {
        id: "STU-001",
        name: "Dawit Bekele",
        enrollmentDate: polyfill_1.Temporal.Now.instant(),
        gpa: 3.4,
    },
    fetchedAt: polyfill_1.Temporal.Now.instant(),
};
console.log((0, api_response_model_1.renderResponse)(studentRes, (s) => `${s.name} GPA: ${s.gpa ?? "N/A"}`));
// Nowtest with a different data type
const courseListRes = {
    status: "success",
    data: [
        {
            id: "CRS-101",
            title: "Web Development Fundamentals",
            capacity: 30,
            startDate: polyfill_1.Temporal.PlainDate.from("2026-09-01"),
        },
    ],
    fetchedAt: polyfill_1.Temporal.Now.instant(),
};
console.log((0, api_response_model_1.renderResponse)(courseListRes, (courses) => courses.map((c) => c.title).join(", ")));
// 1. Record the exact moment an enrollment is approved (UTC)
const approvedAt = polyfill_1.Temporal.Now.instant();
console.log(`Approved at (UTC): ${approvedAt}`);
// 2. Display in local timezone
const addisTime = approvedAt.toZonedDateTimeISO("Africa/Addis_Ababa");
const londonTime = approvedAt.toZonedDateTimeISO("Europe/London");
console.log(`Addis: ${addisTime.toPlainTime()}`);
console.log(`London: ${londonTime.toPlainTime()}`);
// 3. Course start date (date only, no time)
const courseStart = polyfill_1.Temporal.PlainDate.from("2026-09-01");
const today = polyfill_1.Temporal.Now.plainDateISO();
const daysUntilStart = today.until(courseStart).total({ unit: "days" });
console.log(`${Math.floor(daysUntilStart)} days until course starts`);
// 4. Assignment deadline duration
const deadline = polyfill_1.Temporal.PlainDate.from("2026-12-15");
const remaining = today.until(deadline);
console.log(`${remaining.total({ unit: "days" })} days until assignment is due`);
