import { useState } from "react";
import { useTodos } from "../hooks/useTodos"

export default function AddTodoForm(){

    const {createMut,isCreating} = useTodos();

    const [title,setTitle] = useState("");
    const [description,setDescription] = useState("");
    const [deadline, setDeadline] = useState("");
    const [importance, setImportance] = useState(0);


    const handleSubmit = (e) =>{
        e.preventDefault();

        createMut({title,description,deadline,importance,onSuccess:() =>{setTitle("");setDescription(""),setDeadline(""),setImportance(0)}});
    }

    return(
        <form className="add-form" onSubmit={handleSubmit}>
            <h3>New todo</h3>
            <label htmlFor="title">Title</label>
            <input type="text" name="title" value={title} onChange={(e) => {setTitle(e.target.value)}} placeholder="Title" disabled={isCreating}/>
            <label htmlFor="description">Description</label>
            <input type="text" value={description} onChange={(e) => {setDescription(e.target.value)}} placeholder="Description" disabled={isCreating}/>
            <label htmlFor="deadline">Deadline</label>
            <input type="date" name="deadline" value={deadline} onChange={(e) => {setDeadline(e.target.value)}} disabled={isCreating} />
            <label htmlFor="importance">Importance</label>
            <select name="importance" id="importance" onChange={(e) => setImportance(e.target.value)} disabled={isCreating}>
                <option value="0">NotImportant</option>
                <option value="1">Slightly Important</option>
                <option value="2">Important</option>
                <option value="3">Urgent</option>
            </select>
            <button type="submit" disabled={isCreating}>{isCreating?"Saving":"Add"}</button>
        </form>

    )


}