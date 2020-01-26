import React from 'react';
import { AppBar, IconButton, Typography, Toolbar as MaterialToolbar } from '@material-ui/core';
import { LoginButton } from './LoginButton';
import { LogoutButton } from './LogoutButton';

export const Toolbar: React.FC = () => (
    <AppBar position="static">
        <MaterialToolbar>
            <IconButton edge="start" color="inherit" aria-label="menu">
            {/* <MenuIcon /> */}
            </IconButton>
            <Typography variant="h6">            
            </Typography>

            <LoginButton />
            <LogoutButton />

        </MaterialToolbar>
        </AppBar>
);