import React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  useRouteMatch,
  useParams
} from "react-router-dom";
import { ToDo } from './pages/to-do';
import Container from '@material-ui/core/Container';
import { makeStyles } from '@material-ui/core/styles';
import { Paper } from '@material-ui/core';
import { Toolbar } from './components/toolbar/Toolbar';
import { LoginCallback } from './pages/login/LoginCallback';

const useStyles = makeStyles({
  
})

const App: React.FC = () => {
  const classes = useStyles();

  return (
    <React.Fragment>
      <CssBaseline />

      <Container>
        <Router>
          <Toolbar />         

          <Paper>            
            <Switch>
              <Route path="/login-callback">
                <LoginCallback />
              </Route>
              <Route path="/to-do-lists">
                <ToDo />
              </Route>
              <Route path="/">
                <div>Home</div>
              </Route>
            </Switch>
          </Paper>

        </Router>
      </Container> 
  
    </React.Fragment>
    
  );
};

export default App;