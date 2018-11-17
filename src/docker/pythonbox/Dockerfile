FROM alpine:3.8

RUN apk --no-cache add \
    python \
    python-dev \
    py-pip \
    build-base \
    vim \
  && pip install virtualenv --upgrade pip \
  && rm -rf /var/cache/apk/*

CMD /bin/ash
