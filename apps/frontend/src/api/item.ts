import client from "./client";

export const getItems = async () => {
  const { data } = await client.get("/items");
  return data;
};

export const addItem = async (item: string) => {
  const { data } = await client.post("/items", { item });
  return data;
};
