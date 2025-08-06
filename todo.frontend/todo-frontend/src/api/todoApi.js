import axios from 'axios'

const API_URL = "http://localhost:7280/api";

const apiClient = axios.create({
    baseURL : API_URL,
    headers : {
        "Content-Type" : "application/json",
    },
});

export const getAllTodos = async () => {
    const response = await apiClient.get("/todos");
    return response.data;
}

export const getTodoById = async (id) => {
    const response = await apiClient.get(`/todos/${id}`);
    return response.data;
}

export const createTodo = async (newTodo) => {
    const response = await apiClient.post("/todos",newTodo);
    return response.data;
}

export const deleteTodo = async (id) => {
    const response = await apiClient.delete(`/todos/${id}`);
    return response.data;
}

export const updateTodo = async ({id, ...newTodo}) => {
    const response = await apiClient.patch(`/todos/${id}`,newTodo);
    return response.data;
}

