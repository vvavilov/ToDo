import { TodoListClient } from "../../generated/client-api/WebApiClient";
import { userManager } from "./user-manager";
import { Urls } from "../consts/Urls";

class AuthorizedTodoListClient extends TodoListClient {
    protected async transformOptions(options: RequestInit): Promise<RequestInit> {
        const user = await userManager.getUser();
        if(!user) {
            throw new Error("User is not authorized");
        }
        (options.headers as any).Authorization = "Bearer " + user.access_token;
        return options;
    }
}

export const webApiClient = new AuthorizedTodoListClient(Urls.ToDoApi);