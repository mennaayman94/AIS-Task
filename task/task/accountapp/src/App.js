import './App.css'; 
import { BrowserRouter, Route, Switch } from "react-router-dom";
import MaterialTableDemo  from './Components/MaterialTableDemo';
import Category from './Components/Categories';
function App() {
  return (
    <BrowserRouter>
    <switch>
    <Route path="/" exact render={() => <MaterialTableDemo />} />
    </switch>
    <switch>
    <Route path="/Category" render={() => <Category />} />

    </switch>
    </BrowserRouter>
    
    
  )
}

export default App;
