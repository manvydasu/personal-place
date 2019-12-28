import React from 'react';
import './App.css';
import LoginFrom from './LoginForm';
import AppBar from '@material-ui/core/AppBar';
import DataContainer from "./DataContainer";
import {BrowserRouter, Route, Switch} from "react-router-dom";
import Toolbar from '@material-ui/core/Toolbar';

function App() {
  return (
    <div className="App">
      <AppBar position="relative">
        <Toolbar />
      </AppBar>
      <BrowserRouter>
        <Switch>
          <Route exact path="/">
            <LoginFrom/>
          </Route>
          <Route path="/home">
            <DataContainer />
          </Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
