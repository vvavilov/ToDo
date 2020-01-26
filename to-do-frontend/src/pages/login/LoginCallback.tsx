import React, { useEffect } from 'react';
import { Button } from '@material-ui/core';
import { UserManager } from 'oidc-client';
import { useHistory } from 'react-router';

export const LoginCallback: React.FC = () => {
    const history = useHistory();

    useEffect(() => {
        const handleSigninCallback = async () => {
            await new UserManager({ response_mode: "query" }).signinRedirectCallback();
            history.push('/to-do-lists');
        }

        handleSigninCallback();
    });

    return (
        <span>Redirecting to the main page...</span>
    );
    
}

