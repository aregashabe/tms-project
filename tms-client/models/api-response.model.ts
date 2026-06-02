import { Temporal } from "@js-temporal/polyfill";
export type ApiResponse<T> =
| { status: "loading" }
| { status: "success"; data: T; fetchedAt: Temporal.Instant }
| { status: "error"; message: string; statusCode: number };

export function renderResponse<T>(
  response: ApiResponse<T>,
  formatter: (data: T) => string,
): string {
  switch (response.status) {
    case "loading":
      return "Loading...";
    case "success":
      return formatter(response.data);
    case "error":
      return `Error ${response.statusCode}: ${response.message}`;
  }
}
// TODO: Handle all three states with a switch on response.status.
// "loading" → return "Loading..."
// "success" → call the formatter with response.data
// "error" → return a string with the statusCode and message
