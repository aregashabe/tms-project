"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.describeCourse = describeCourse;
function describeCourse(status) {
    switch (status.status) {
        case "DRAFT":
            return `Draft created by ${status.createdBy} `;
        case "PUBLISHED":
            return `Published on ${status.publishedAt}`;
        case "ACTIVE":
            return `Active starting $ with ${status.enrolledCount} students enrolled`;
        case "ARCHIVED":
            return `Archived on $ with final enrollment count: ${status.finalEnrollmentCount}`;
        case "CANCELLED":
            return `Cancelled on $ for reason: ${status.reason}`;
        default:
            const _exhaustiveCheck = status;
            throw new Error(`Unhandled status: ${JSON.stringify(_exhaustiveCheck)}`);
    }
}
