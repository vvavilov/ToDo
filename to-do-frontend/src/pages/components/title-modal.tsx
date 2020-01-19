import React, { useState } from 'react';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';

interface TitleModalProps {
    isOpen: boolean;
    title: string;
    onTitleChange(title: string): void;
    onSave(): void;    
    onCancel(): void;    
}

export const TitleModal = (props: TitleModalProps) => {

    return (
    <Dialog open={props.isOpen} aria-labbeledby="form-dialog-title">
        <DialogTitle id="form-dialog-title">ToDo List Title</DialogTitle>
        <DialogContent>
            <DialogContentText>
                Please enter a new title.
            </DialogContentText>
            <TextField value={props.title} onChange={(e) => props.onTitleChange(e.target.value)} />
        </DialogContent>
        <DialogActions>
            <Button onClick={props.onCancel}>Cancel</Button>
            <Button onClick={props.onSave}>Save</Button>
        </DialogActions>
    </Dialog>)
}