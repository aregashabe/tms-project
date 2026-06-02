"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.describeEnrollment = describeEnrollment;
function describeEnrollment(enrollment) {
    switch (enrollment.status) {
        case "PENDING":
            return `Awaiting approval since ${enrollment.requestedAt}`;
        case "APPROVED":
            return `Approved by ${enrollment.approvedBy}`;
        case "ACTIVE":
            return enrollment.currentGrade !== undefined
                ? `In progress grade so far: ${enrollment.currentGrade}`
                : `In progress not yet graded`;
        case "COMPLETED":
            return `Finished with ${enrollment.finalGrade}`;
        case "DROPPED":
            return `Dropped: ${enrollment.reason}`;
        default: {
            const _check = enrollment;
            throw new Error(`Unhandled status: ${JSON.stringify(_check)}`);
        }
    }
}
