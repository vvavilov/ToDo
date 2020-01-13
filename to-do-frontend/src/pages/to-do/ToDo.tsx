import React, { useEffect, useState } from 'react';
import { webApiClient } from '../../shared/services/web-api';
import { ToDoListVm } from '../../generated/client-api/WebApiClient';
import { Typography, TableContainer, Paper, TableHead, Table, TableCell, TableRow, TableBody, IconButton, Icon, Button, TextField } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import Delete from '@material-ui/icons/Delete';
import AddIcon from '@material-ui/icons/Add';

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

export const ToDo = () => {
    const deleteToDoList = async (id: string): Promise<void> => {
        await webApiClient.delete(id);
        setToDoLists(toDoLists.filter(x => x.id !== id));
    }
    const fetchToDoLists = async (): Promise<void> => {
        setToDoLists(await webApiClient.getAll() || []);
    }
    const createNewList = async (): Promise<void> => {
        const created = await webApiClient.add(newListTitle);
        setToDoLists([created, ...toDoLists]);
    }

    const classes = useStyles();
    const [toDoLists, setToDoLists] = useState<ToDoListVm[]>([]);
    const [newListTitle, setNewListTitle] = useState<string | null>(null);
    
    useEffect(() => {        
        fetchToDoLists();
    }, []);

    return (
        <Paper className={classes.paper}>
            <Typography variant="h3" component="h2" gutterBottom>
                To Do
            </Typography>
            <TextField id="title" label="Title" value={newListTitle} onChange={(e) => setNewListTitle(e.target.value)} />
            <Button
                onClick={createNewList}
                variant="contained"
                color="primary"
                endIcon={<AddIcon />}
            >
                Create
            </Button>


            <TableContainer >
                <Table aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Title</TableCell>
                            <TableCell></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {toDoLists.map(item => (
                            <TableRow key={item.id}>
                                <TableCell component="th" scope="item">
                                    {item.title}
                                </TableCell>
                                <TableCell>
                                <IconButton onClick={() => deleteToDoList(item.id!)} aria-label="delete">
                                    <Delete />
                                </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Paper>
    );
};


