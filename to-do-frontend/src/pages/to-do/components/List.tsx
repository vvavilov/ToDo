import React, { useEffect, useState } from 'react';
import { Typography, TableContainer, Paper, TableHead, Table, TableCell, TableRow, TableBody, IconButton, Icon, Button, TextField } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import Delete from '@material-ui/icons/Delete';
import Create from '@material-ui/icons/Create';
import AddIcon from '@material-ui/icons/Add';
import { ToDoListVm } from '../../../generated/client-api/WebApiClient';

const useStyles = makeStyles(theme => ({
    paper: {
        padding: '12px'
    },
    button: {
        margin: '6px'
    },
    newListForm: {
        margin: '6px 12px 6px 0',
        display: 'inline-flex'
    }
}));

export interface ListProps {
    items: ToDoListVm[];
    onDelete(id: string): void;
    onChange(id: string): void;
}

export const List: React.FC<ListProps> = (props: ListProps) => {
    const classes = useStyles();

    const { items, onDelete, onChange } = props;

    return (
    <TableContainer >
        <Table aria-label="simple table">
            <TableHead>
                <TableRow>
                    <TableCell>Title</TableCell>
                    <TableCell></TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {items.map(item => (
                    <TableRow key={item.id}>
                        <TableCell component="th" scope="item">
                            {item.title}
                        </TableCell>
                        <TableCell>
                        <IconButton onClick={() => onDelete(item.id!)} aria-label="delete">
                            <Delete />
                        </IconButton>
                        <IconButton onClick={() => onChange(item.id!)} aria-label="create">
                            <Create />
                        </IconButton>
                        </TableCell>
                    </TableRow>
                ))}
            </TableBody>
        </Table>
    </TableContainer>);
};


