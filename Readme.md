Описание инфраструктуры для демонстраций в рамках воркшопа "Метрики, алертинги и дашборды" https://podlodka.io/qacrew

# Commands

Запуск:
```
docker-compose up -d
```

Пересоздать все контейнеры:
```
docker-compose up -d --force-recreate
```

Остановка:
```
docker-compose down
```

Перезагрузка конфигурации prometheus
```
curl -X POST -I 'http://localhost:9090/-/reload'
```

Перезагрузка конфигурации alertmanager
```
curl -X POST -I 'http://localhost:9090/-/reload'
```

-----------------------
# URLs

Prometheus:
http://localhost:9090/graph

Alertmanager:
http://localhost:9093/

Grafana:
http://localhost:3000/

Elastic + Kibana:
http://localhost:5601/
