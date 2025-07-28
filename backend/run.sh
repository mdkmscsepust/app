#!/bin/bash
echo "Starting FastApi project server..."
if [-d "venv"]; then
    echo "Activate"
    source venv/bin/activate
else 
    echo "Creating virtual environment..."
    python3 -m venv app/venv
    source app/venv/bin/activate
    echo "Installing requirements..."
    pip install -r requirements.txt
    exit 1
fi

eacho "Running server..."
uvicorn app.main:app --reload
eacho "Server running at http://localhost:8000"
