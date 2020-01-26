import React from 'react';
import { Button } from '@material-ui/core';
import { userManager } from '../../shared/services/user-manager';

export const LoginButton: React.FC = () => {
    return (
        <Button color='inherit' onClick={login}>
            Login
        </Button>
    );
}

const login = () => {
    userManager.signinRedirect();
}