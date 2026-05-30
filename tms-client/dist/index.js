"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const polyfill_1 = require("@js-temporal/polyfill");
const student = {
    id: "STU-001",
    name: "Hana Tadesse",
    enrollmentDate: polyfill_1.Temporal.Now.instant(),
};
// Try these what does the compiler say?
student.id = "STU-999";
// console.log(student.gpa.toFixed(2));
console.log(student.gpa?.toFixed(2) ?? "Not yet graded");
