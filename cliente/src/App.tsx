import React, { useEffect } from 'react';
import Container from './components/Container/Container';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import { Provider } from 'react-redux'
import store from './redux/store';
import { test1 } from './tests';
import populateProvinciaAction from './redux/actions/provincia/populateProvinciaAction'
import populateVacunaAction from './redux/actions/vacuna/populateVacunaAction'
import populateVacunadoAction from './redux/actions/vacunado/populateVacunadoAction';


function App() {

  useEffect(() => {
    test1()
    store.dispatch<any>(populateProvinciaAction())
    store.dispatch<any>(populateVacunaAction())
    store.dispatch<any>(populateVacunadoAction({}))

  }, [])


  return (
    <BrowserRouter>
      <Provider store={store}>
        <Container />
      </Provider>
    </BrowserRouter>
  );
}

export default App;
