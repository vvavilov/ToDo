import { TodoListClient } from "../../generated/client-api/WebApiClient";

const baseUrl = "https://localhost:5001";

export const webApiClient = new TodoListClient(baseUrl);