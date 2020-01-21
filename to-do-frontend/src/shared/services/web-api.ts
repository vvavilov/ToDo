import { TodoListClient } from "../../generated/client-api/WebApiClient";


const baseUrl = process.env.NODE_ENV === 'development' 
    ? 'https://localhost:5001/'
    : process.env.REACT_APP_API_URL;

export const webApiClient = new TodoListClient(baseUrl);