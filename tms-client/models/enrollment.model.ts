import { Temporal } from "@js-temporal/polyfill";
export interface EnrollmentRecord {
readonly studentId: string;
readonly courseCode: string;
enrolledAt: Temporal.Instant;
}