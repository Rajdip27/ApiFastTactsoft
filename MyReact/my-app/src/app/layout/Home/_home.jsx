"use client";
import { useState, useEffect } from "react";
import Layout from "../_layout";
export default function HomePage() {
  const [category, setCategory] = useState([]);
  useEffect(() => {
    fetch("https://localhost:44391/Category")
      .then((res) => res.json())
      .then((data) => {
        setCategory(data);
        console.log(data);
      });
  }, []);
  return (
    <Layout>
      <div className=" container mt-3  ">
        <h4 className=" bg-primary  text-center"> Category List</h4>
        <table className=" table  table-bordered mt-3">
          <thead>
            <tr className=" text-center ">
              <th>#</th>
              <th>Category Name</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {category.map((index, data) => (
              <tr key={data} className=" text-center ">
                <td>{data + 1}</td>
                <td>{index.categoryName}</td>
                <td>
                  <button className=" btn btn-primary ">Edit</button>|
                  <button className="btn btn-danger ">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </Layout>
  );
}
