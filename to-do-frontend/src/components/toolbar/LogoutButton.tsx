import React from 'react';
import { Button } from '@material-ui/core';
import { userManager } from '../../shared/services/user-manager';

export const LogoutButton: React.FC = () => {
    return (
        <Button color='inherit' onClick={logout}>
            Logout
        </Button>
    );
}

const logout = () => {
    userManager.signoutRedirect();
}