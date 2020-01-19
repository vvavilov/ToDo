import React, { useEffect, useState, Fragment } from 'react';
import { webApiClient } from '../../shared/services/web-api';
import { ToDoListVm } from '../../generated/client-api/WebApiClient';
import { Typography, Paper, Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import AddIcon from '@material-ui/icons/Add';
import { List } from '../components/list';
import { TitleModal } from '../components/title-modal';
import { ViewState } from '../../shared/types/view-state';
import { Nullable } from '../../shared/types/nullable';

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
    const classes = useStyles();
    const [toDoLists, setToDoLists] = useState<ToDoListVm[]>([]);
    const [selectedList, setSelectedList] = useState<Nullable<ToDoListVm>>(null);
    const [selectedListTitle, setSelectedListTitle] = useState<string>('');
    const [viewState, setViewState] = useState(ViewState.View);

    const deleteToDoList = async (id: string): Promise<void> => {
        await webApiClient.delete(id);
        setToDoLists(toDoLists.filter(x => x.id !== id));
    }

    const fetchToDoLists = async (): Promise<void> => {
        setToDoLists(await webApiClient.getAll());
    }
    
    const handleOnCreateClick = async (): Promise<void> => {
        setViewState(ViewState.Create);
    }

    const handleOnChangeClick = async (id: string): Promise<void> => {
        const list = toDoLists.find(x => x.id === id);
        if(!list) {
            throw new Error(`Element was not found: ${id}`)
        }
        setSelectedList(list);
        setSelectedListTitle(list.title!);
        setViewState(ViewState.Edit);
    }    
    
    const saveToDoList = async () => {
        if(!selectedList) {
            throw new Error('List is not selected');
        }

        const updated = await webApiClient.update({ ...selectedList, title: selectedListTitle });
        setToDoLists(toDoLists.map(list => list.id === updated.id
            ? updated
            : list));
        closeTitleModal();
    }

    const createToDoList = async () => {
        const created = await webApiClient.add({ title: selectedListTitle });
        setToDoLists([created, ...toDoLists]);
        closeTitleModal();
    }

    const closeTitleModal = () => {
        setSelectedListTitle('');
        setViewState(ViewState.View);
    }

    useEffect(() => {        
        fetchToDoLists();
    }, []);

    return (
        <Fragment>
            <Paper className={classes.paper}>
                <Typography variant="h3" component="h2" gutterBottom>
                    To Do
                </Typography>
                <Button
                    onClick={handleOnCreateClick}
                    variant="contained"
                    color="primary"
                    endIcon={<AddIcon />}
                >
                    Create
                </Button>

                <List 
                    items={toDoLists} 
                    onChange={handleOnChangeClick} 
                    onDelete={deleteToDoList} 
                />            
            </Paper>

            <TitleModal 
                isOpen={viewState === ViewState.Edit} 
                title={selectedListTitle} 
                onSave={saveToDoList}
                onTitleChange={(title) => setSelectedListTitle(title)}
                onCancel={closeTitleModal} 
            />

            <TitleModal 
                isOpen={viewState === ViewState.Create} 
                title={selectedListTitle} 
                onSave={createToDoList}
                onTitleChange={(title) => setSelectedListTitle(title)}
                onCancel={closeTitleModal} />
        </Fragment>
    );
};


