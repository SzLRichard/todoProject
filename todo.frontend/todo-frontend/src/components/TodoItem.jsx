import { useTodos } from "../hooks/useTodos"

export default function TodoItem({todo}){

    const {deleteMut,isDeleting} = useTodos();
    return (
        <li className="todo-item">
            <div>
                <h4>{todo.name}</h4>
                <p>{todo.description || "None"}</p>
                <p>Status: {todo.status}</p>
                <p>Importance: {todo.importance}</p>
                <p>Deadline: {todo.deadline}</p>
            </div>
            <button onClick={()=>{deleteMut(todo.id)}} disabled={isDeleting}>Delete</button>
        </li>

    )
}