"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.isStudent = isStudent;
exports.parseStudent = parseStudent;
const polyfill_1 = require("@js-temporal/polyfill");
function isStudent(value) {
    return (typeof value === "object" &&
        value !== null &&
        "id" in value &&
        "name" in value &&
        typeof value.id === "string" &&
        typeof value.name === "string");
}
function parseStudent(raw) {
    if (typeof raw !== "object" || raw === null) {
        throw new TypeError(`Expected an object, received ${raw === null ? "null" : typeof raw}`);
    }
    const obj = raw;
    if (typeof obj.id !== "string") {
        throw new TypeError(`Expected id to be a string, received ${typeof obj.id}`);
    }
    if (typeof obj.name !== "string") {
        throw new TypeError(`Expected name to be a string, received ${typeof obj.name}`);
    }
    return {
        id: obj.id,
        name: obj.name,
        enrollmentDate: polyfill_1.Temporal.Now.instant(),
    };
}
