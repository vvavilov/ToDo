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
import { Grid, AppBar, Toolbar, IconButton, Typography, Button, Paper } from '@material-ui/core';

const useStyles = makeStyles({
  
})

const App: React.FC = () => {
  const classes = useStyles();

  return (
    <React.Fragment>
      <CssBaseline />

      <Container>

        <AppBar position="static">
          <Toolbar>
            <IconButton edge="start" color="inherit" aria-label="menu">
              {/* <MenuIcon /> */}
            </IconButton>
            <Typography variant="h6">
              
            </Typography>
            <Button color="inherit">Login</Button>
          </Toolbar>
        </AppBar>

        <Paper>

          <Router>
            <Switch>
              <Route path="/to-do-lists">
                <ToDo />
              </Route>
              <Route path="/">
                <div>Home</div>
              </Route>
            </Switch>
          </Router>

        </Paper>

      </Container>

    

    </React.Fragment>
    
  );
};

export default App;