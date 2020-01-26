
const toDoApi = process.env.NODE_ENV === 'development' 
    ? 'https://localhost:5001'
    : process.env.REACT_APP_API_URL;

const authorizationApi = process.env.NODE_ENV === 'development' 
    ? 'http://localhost:5000'
    : process.env.REACT_APP_AUTHORIZATION_API_URL;

const reactClient = process.env.NODE_ENV === 'development' 
    ? 'http://localhost:3000'
    : process.env.REACT_APP_REACT_CLIENT;

export const Urls = {
    ToDoApi: toDoApi,
    AuthorizationApi: authorizationApi,
    ReactClient: reactClient
}