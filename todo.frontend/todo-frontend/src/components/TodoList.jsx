import {useTodos} from "../hooks/useTodos.js"
import TodoItem from "./TodoItem.jsx"


export default function TodoList () {

    const {todos,isLoading,isError,error} = useTodos();

    if(isLoading){
        return (
            <div>
                Loading todos...
            </div>
        )
    }
    if(isError){
        return(
            <div className="error">
                Error occured: {error.message}
            </div>
        )
    }

    return (
        <ul className="todo-list">
        {todos?.map((todo) => (
            <TodoItem key={todo.id} todo={todo} />
        ))}
        </ul>
    );

}