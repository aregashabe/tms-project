import { Temporal } from "@js-temporal/polyfill";
export interface Student {
 id: string;
name: string;
enrollmentDate: Temporal.Instant;
gpa?: number; // Optional undefined until the student receives a grade
}
