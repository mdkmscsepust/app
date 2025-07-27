import requests
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)
@app.get("/llm")
def get_llm():
    url = "https://89c9bbc8c63c.ngrok-free.app/api/generate"
    payload = {
        "model":"llama3",
        "prompt": "Tell me a joke about cats",
        "stream": False
    }
    headers = {
        "Content-Type": "application/json"
    }
    response = requests.post(url=url, json=payload, headers=headers)
    return {"response": response.json()["response"]} 