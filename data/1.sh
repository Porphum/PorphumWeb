#!/bin/bash

# SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )

# echo $SCRIPT_DIR
# SCR_PATH=$SCRIPT_DIR/a/script.sh

# echo $SCR_PATH

# . "$SCR_PATH"

set -e

echo "start"
find /docker-entrypoint-initdb.d -mindepth 2 -type f -print0 | while read -d $'\0' f; do
  echo "debug $f"
  case "$f" in
    # *.sh)
    #   if [ -x "$f" ]; then
    #     echo "$0: running $f"
    #     "$f"
    #   else
    #     echo "$0: sourcing $f"
    #     . "$f"
    #   fi
    #   ;;
    *.sql)    echo "$0: running $f"; psql --username "$POSTGRES_USER" -f "$f"; echo ;;
    # *.sql.gz) echo "$0: running $f"; gunzip -c "$f" | "${psql[@]}"; echo ;;
    *)        echo "$0: ignoring $f" ;;
  esac
  echo
done
echo "done"

