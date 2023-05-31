from diagrams import Diagram, Cluster
from diagrams.onprem.queue import RabbitMQ
from diagrams.azure.compute import AppServices;

with Diagram("Event Driven - Broker/Choreography Topology", show=False, filename="big_picture_broker", direction="TB"):
    with Cluster("Kubernetes"):   
        with Cluster("cooking_container"):
            cooking_service = AppServices("CookingService")
        with Cluster("event_queue_container"):
            queue = RabbitMQ("bread queue")
        with Cluster("bread_container"):
            bread = AppServices("BreadService")
        with Cluster("event_queue_container"):
            cheese_queue = RabbitMQ("cheese queue")
        with Cluster("cheese_container"):
            cheese = AppServices("CheeseService")
        with Cluster("event_queue_container"):
            steak_queue = RabbitMQ("steak queue")
        with Cluster("steak_container"):
            steak = AppServices("SteakService")

    workers = [bread, cheese, steak]
    
    cooking_service >> queue >> bread >> cheese_queue >> cheese >> steak_queue >> steak