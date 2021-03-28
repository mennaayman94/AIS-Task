import React, { useState, useEffect } from "react";
import MaterialTable from "material-table";
import axios from "axios";
import Header from "../Components/Header";
import Footer from "../Components/Footer";
export default function Category() {
  const [state, setState] = useState({
    columns: [{ title: "Category Name", field: "CategoryName" }],
    data: [],
  });
  useEffect(() => {
    const fetchData = async () => {
      const result = await axios.get("http://localhost:64761/api/Category");

      setState({ columns: state.columns, data: result.data });
      console.log(result);
    };
    fetchData();
  }, []);

  async function addCategory(newCategory) {
    const result = await axios.post(
      "http://localhost:64761/api/Category",
      newCategory
    );
    console.log(result);
    if (result.data.message) {
      alert(result.data.message);
    } else {
      setState({ columns: state.columns, data: [...state.data, result.data] });
    }
  }

  async function deleteCategory(id) {
    const result = await axios.delete(
      `http://localhost:64761/api/Category/${id}`
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

  async function editCategory(id, editedCategory) {
    const result = await axios.put(
      `http://localhost:64761/api/Category/${id}`,
      editedCategory
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
        title="Categories"
        columns={state.columns}
        data={state.data}
        editable={{
          onRowAdd: (newCategory) =>
            new Promise((resolve) => {
              resolve();
              addCategory(newCategory);
            }),
          onRowUpdate: (newData, oldData) =>
            new Promise((resolve) => {
              const id = oldData.ID;
              resolve();

              editCategory(id, newData, oldData);
            }),
          onRowDelete: (oldData) =>
            new Promise((resolve) => {
              const id = oldData.ID;
              resolve();
              deleteCategory(id, oldData);
            }),
        }}
      />
      <Footer />
    </div>
  );
}
