import React from 'react';
import './App.css';
import AppBar from '@material-ui/core/AppBar';
import {BrowserRouter, Route, Switch} from "react-router-dom";
import Toolbar from '@material-ui/core/Toolbar';

import LoginFrom from './components/LoginForm';
import DataContainer from "./components/DataContainer";

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
