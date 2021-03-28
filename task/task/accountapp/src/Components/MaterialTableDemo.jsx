import React, { useState, useEffect } from "react";
import { Link, NavLink } from "react-router-dom";
import MaterialTable from "material-table";
import axios from "axios";
import Header from "../Components/Header";
import Footer from "../Components/Footer";
var DropDownList = {};
export default function MaterialTableDemo() {
  var DynamicDropdown = async () => {
    var result = await axios.get("http://localhost:64761/api/Category");
    console.log(result.data);
    var obj = result.data;
    DropDownList = obj.reduce(function (acc, cur, i) {
      acc[cur.ID] = cur.CategoryName;

      return acc;
    }, {});
  };
  const [state, setState] = useState({
    columns: [],

    data: [],
  });

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios.get("http://localhost:64761/api/Accounts");

      setState({ columns: state.columns, data: result.data });
      console.log(result);
    };

    fetchData();
    DynamicDropdown();
  }, []);

  async function addAccount(newAccount) {
    const result = await axios.post(
      "http://localhost:64761/api/Accounts",
      newAccount
    );
    console.log(result);
    if (result.data.message) {
      alert(result.data.message);
    } else {
      setState({ columns: state.columns, data: [...state.data, result.data] });
    }
  }

  async function deleteAccount(id) {
    const result = await axios.delete(
      `http://localhost:64761/api/Accounts/${id}`
    );
    let NewResult = [...state.data];
    state.data.forEach((element, index) => {
      if (element.ID === result.data.ID) {
        NewResult.splice(index, 1);
      }
    });
    console.log(NewResult);
    setState({ columns: state.columns, data: NewResult });
  }

  async function editAccount(id, editedAccount) {
    const result = await axios.put(
      `http://localhost:64761/api/Accounts/${id}`,
      editedAccount
    );
    let newData = [...state.data];
    state.data.forEach((element, index) => {
      console.log(element.ID);
      console.log(result.data.ID);
      if (element.ID === result.data.ID) {
        newData[index] = result.data;
        console.log(element);
        console.log(result.data);
      }
    });
    setState({ columns: state.columns, data: newData });
  }

  return (
    <div>
      <Header />
      <MaterialTable
        title="Accounts"
        columns={[
          { title: "Customer Name", field: "CustomerName" },
          { title: "Balance", field: "Balance" },
          {
            title: "Category Name",
            field: "CategoryID",
            lookup: DropDownList,
          },
          {
            title: "Account Type",
            field: "TypeID",
            lookup: { 1: "Debit", 2: "Credit" },
          },
        ]}
        data={state.data}
        editable={{
          onRowAdd: (newAccount) =>
            new Promise((resolve) => {
              resolve();
              addAccount(newAccount);
            }),
          onRowUpdate: (newData, oldData) =>
            new Promise((resolve) => {
              const id = oldData.ID;
              resolve();

              editAccount(id, newData, oldData);
            }),
          onRowDelete: (oldData) =>
            new Promise((resolve) => {
              const id = oldData.ID;
              resolve();
              deleteAccount(id, oldData);
            }),
        }}
      />
      <Footer />
    </div>
  );
}
