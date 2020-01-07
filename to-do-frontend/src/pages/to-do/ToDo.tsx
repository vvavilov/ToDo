import React, { useEffect, useState } from 'react';
import { webApiClient } from '../../shared/services/web-api';
import { ToDoListVm } from '../../generated/client-api/WebApiClient';

export const ToDo = () => {
    const [toDoLists, setToDoLists] = useState<ToDoListVm[]>([]);
    
    useEffect(() => {
        const fetchToDoLists = async (): Promise<void> => {
            setToDoLists(await webApiClient.getAll() || []);
        }
        fetchToDoLists();
    }, []);

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>Title</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        toDoLists.map(list => 
                            (<tr>
                                <td>{list.title}</td>
                            </tr>))
                    }         
                </tbody>
            </table>
        </div>
    );
};


