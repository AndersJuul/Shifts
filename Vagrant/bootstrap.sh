#!/usr/bin/env bash

## Initial 
wget -qO - https://packages.elastic.co/GPG-KEY-elasticsearch | sudo apt-key add -
echo "deb http://packages.elastic.co/kibana/4.4/debian stable main" | sudo tee -a /etc/apt/sources.list
apt-get update
ufw disable
apt-get install -y curl

## RabbitMQ 
apt-get install -y erlang-nox
wget https://github.com/rabbitmq/rabbitmq-server/releases/download/rabbitmq_v3_5_4/rabbitmq-server_3.5.4-1_all.deb
dpkg -i rabbitmq-server_3.5.4-1_all.deb
rm rabbitmq-server_3.5.4-1_all.deb
echo "[{rabbit, [{loopback_users, []}]}]." >> /etc/rabbitmq/rabbitmq.config
rabbitmq-plugins enable rabbitmq_management
service rabbitmq-server restart

## Elasticsearch 
add-apt-repository ppa:webupd8team/java -y
apt-get update
echo oracle-java8-installer shared/accepted-oracle-license-v1-1 select true | sudo /usr/bin/debconf-set-selections
apt-get install -y oracle-java8-installer
apt-get install -y oracle-java8-set-default
wget https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-5.1.1.deb
sha1sum elasticsearch-5.1.1.deb 
sudo dpkg -i elasticsearch-5.1.1.deb
rm elasticsearch-5.1.1.deb
chmod o+w /etc/elasticsearch/elasticsearch.yml
echo "discovery.zen.ping.multicast.enabled: false" >> /etc/elasticsearch/elasticsearch.yml
echo "index.number_of_replicas: 0" >> /etc/elasticsearch/elasticsearch.yml
echo "index.number_of_shards: 1" >> /etc/elasticsearch/elasticsearch.yml
echo "script.groovy.sandbox.enabled: true" >> /etc/elasticsearch/elasticsearch.yml
echo "network.host: _non_loopback_" >> /etc/elasticsearch/elasticsearch.yml
echo "network.bind_host: 0" >> /etc/elasticsearch/elasticsearch.yml
echo "script.inline: true" >> /etc/elasticsearch/elasticsearch.yml
echo "script.indexed: true" >> /etc/elasticsearch/elasticsearch.yml
chmod o-w /etc/elasticsearch/elasticsearch.yml
update-rc.d elasticsearch defaults 95 10
cd /usr/share/elasticsearch
bin/plugin install lmenezes/elasticsearch-kopf
bin/plugin install mobz/elasticsearch-head
bin/plugin install elastic/sense
bin/plugin install license
bin/plugin install marvel-agent

# Start Elasticsearch
/etc/init.d/elasticsearch start

# Let Elasticsearch get online
until $(curl --output /dev/null --silent --head --fail http://localhost:9200); do
    printf 'Waiting for Elasticsearch to start'
    sleep 1
done

# Install Elasticsearch logstash template
curl -XPUT localhost:9200/_template/logstore -d '{
  "template": "logstash*",
  "settings": {
    "index.analysis.analyzer.default.stopwords": "_none_",
    "index.number_of_replicas": "0",
    "index.query.default_field": "message",
    "index.refresh_interval": "1s",
    "index.number_of_shards": "1",
    "index.store.compress.stored": "true",
    "index.analysis.analyzer.default.type": "standard",
    "index.cache.field.type": "soft"
  },
  "mappings": {
    "_default_": {
      "dynamic_templates": [
        {
          "string_fields": {
            "mapping": {
              "type": "multi_field",
              "fields": {
                "raw": {
                  "index": "not_analyzed",
                  "ignore_above": 256,
                  "type": "string"
                },
                "{name}": {
                  "index": "analyzed",
                  "omit_norms": true,
                  "index_options": "docs",
                  "type": "string"
                }
              }
            },
            "path_match": "fields.*",
            "match_mapping_type": "string"
          }
        }
      ],
      "properties": {
        "message": {
          "index": "analyzed",
          "type": "string"
        },
        "@timestamp": {
          "index": "not_analyzed",
          "type": "date"
        },
        "level": {
          "index": "not_analyzed",
          "type": "string"
        },
        "exception": {
          "dynamic": true,
          "type": "object"
        },
        "messageTemplate": {
          "index": "analyzed",
          "type": "string"
        }
      },
      "_all": {
        "enabled": false
      }
    }
  }
}'


## Kibana 
apt-get install kibana
cd /opt/kibana
bin/kibana plugin --install elastic/sense
bin/kibana plugin --install elasticsearch/marvel/2.2.1
chown kibana:root /opt/kibana/optimize/.babelcache.json
update-rc.d kibana defaults 95 10
/etc/init.d/kibana start