import { UserManager, UserManagerSettings } from 'oidc-client';
import { Urls } from '../consts/Urls';

const config: UserManagerSettings = {
    authority: Urls.AuthorizationApi,
    client_id: "ToDoReactClient",
    redirect_uri: `${Urls.ReactClient}/login-callback`,
    response_type: "code",
    // scope:"openid profile ToDo",
    scope:"openid ToDo",
    post_logout_redirect_uri : Urls.ReactClient,
};

export const userManager = new UserManager(config);